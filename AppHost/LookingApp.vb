Imports System.ComponentModel
Imports System.Threading
Friend Class LookingApp : Implements IDisposable
    Friend Const DefaultRestart As Integer = 50
    Friend Const DefaultCheckTimer As Integer = 30
    Private WithEvents BW As BackgroundWorker
    Friend Property AppName As String
    Friend Property AppPath As SFile
    Friend Property LookAppNameInsteadPath As Boolean = False
    Friend Property AppCheckTimer As Integer = DefaultCheckTimer
    Friend Property RestartedCount As Integer = 0
    Friend Property RestartPrevent As Integer = DefaultRestart
    Friend Sub New()
        BW = New BackgroundWorker With {.WorkerReportsProgress = True, .WorkerSupportsCancellation = True}
    End Sub
    Friend Sub Start()
        If Not AppName.IsEmptyString And Not AppPath.IsEmptyString Then
            If AppCheckTimer = 0 Then AppCheckTimer = 30
            If RestartPrevent = 0 Then RestartPrevent = 50
            _StopRequsted = False
            BW.RunWorkerAsync()
        End If
    End Sub
    Private _StopRequsted As Boolean = False
    Friend Sub [Stop]()
        If BW.IsBusy Then BW.CancelAsync() : _StopRequsted = True
    End Sub
    Private Class FileChecker : Implements IEqualityComparer(Of SFile)
        Private ReadOnly LookAppNameInsteadPath As Boolean
        Friend Sub New(ByVal _LookAppNameInsteadPath As Boolean)
            LookAppNameInsteadPath = _LookAppNameInsteadPath
        End Sub
        Friend Overloads Function Equals(ByVal x As SFile, ByVal y As SFile) As Boolean Implements IEqualityComparer(Of SFile).Equals
            If LookAppNameInsteadPath Then
                Return x.Name = y.Name
            Else
                Return x.Equals(y)
            End If
        End Function
        Private Overloads Function GetHashCode(ByVal Obj As SFile) As Integer Implements IEqualityComparer(Of SFile).GetHashCode
            Throw New NotImplementedException()
        End Function
    End Class
    Private Sub BW_DoWork(sender As Object, e As DoWorkEventArgs) Handles BW.DoWork
        Try
            Dim eq As New FileChecker(LookAppNameInsteadPath)
            Dim CheckProcess As Func(Of Boolean) = Function() As Boolean
                                                       For i% = 0 To 2
                                                           If Not GetProcesses.Contains(AppPath, eq) Then
                                                               If i < 2 Then
                                                                   Thread.Sleep(500)
                                                               Else
                                                                   Return False
                                                               End If
                                                           Else
                                                               Return True
                                                           End If
                                                       Next
                                                       Return False
                                                   End Function
            Do While Not disposedValue And Not _StopRequsted And RestartedCount <= RestartPrevent And _GetProcessError <= 100
                If Not CheckProcess.Invoke() Then Process.Start(AppPath) : RestartedCount += 1 : MyMainLOG = $"Application {AppName} ({AppPath}) restarted"
                Thread.Sleep(AppCheckTimer * 1000)
            Loop
        Catch ex As Exception
            MSDONE("Unexpected error on [LookingApp] back worker", MsgBoxStyle.Critical, ex, False, False, True)
        End Try
    End Sub
    Private _GetProcessError As Integer = 0
    Private Function GetProcesses() As List(Of SFile)
        Try
            With Process.GetProcesses
                If .Count > 0 Then
                    Dim l As New List(Of SFile)
                    For i% = 0 To .Count - 1
                        Try
                            With .ElementAt(i)
                                If Not .MainModule Is Nothing Then
                                    l.Add(.MainModule.FileName)
                                ElseIf Not .Modules Is Nothing AndAlso .Modules.Count > 0 AndAlso Not .Modules(0) Is Nothing Then
                                    l.Add(.Modules(0).FileName)
                                End If
                            End With
                        Catch wex As Win32Exception
                        End Try
                    Next
                    Return l
                End If
            End With
            Return New List(Of SFile)
        Catch ex As Exception
            MSDONE("Unexpected error on process getting", MsgBoxStyle.Critical, ex, False, False, True)
            _GetProcessError += 1
            Return New List(Of SFile)
        End Try
    End Function
    Public Overrides Function ToString() As String
        Return AppName
    End Function
#Region "IDisposable Support"
    Private disposedValue As Boolean = False
    Protected Overridable Overloads Sub Dispose(ByVal disposing As Boolean)
        If Not disposedValue Then
            If disposing Then Me.Stop()
            disposedValue = True
        End If
    End Sub
    Protected Overrides Sub Finalize()
        Dispose(False)
        MyBase.Finalize()
    End Sub
    Friend Overloads Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region
End Class