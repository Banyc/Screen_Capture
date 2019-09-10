﻿Imports System.ComponentModel
Imports System.Windows
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Animation

Public Class LoadingBox
    Private Sub LoadingBox_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        Dim hwnd = New System.Windows.Interop.WindowInteropHelper(Me).Handle
        ClickThruWindow.SetWindowExTransparent(hwnd)
        ResizeWindow()
    End Sub

    Public Sub Teminate(Optional ByVal endingWords As String = "Done")
        If endingWords.Count > 10 Then
            endingWords = endingWords.Substring(0, 5) & " ... " & endingWords.Substring(endingWords.Count - 5, 5)
        End If
        Label.Text = endingWords
        ResizeWindow()
        Me.Close()
    End Sub

    Public Sub ShowError(ex As Exception)
        Label.Text = ex.Message

        ResizeWindow()

        '  DispatcherTimer setup
        Dim dispatcherTimer = New Threading.DispatcherTimer()
        AddHandler dispatcherTimer.Tick, AddressOf dispatcherTimer_Tick
        dispatcherTimer.Interval = New TimeSpan(0, 0, 5)
        dispatcherTimer.Start()
    End Sub

    Private Sub dispatcherTimer_Tick(ByVal sender As Object, ByVal e As EventArgs)
        Me.Close()
    End Sub

    ' resizes this window and locates it on the center
    Private Sub ResizeWindow()
        Label.TextWrapping = TextWrapping.NoWrap
        UpdateLayout()
        If Label.ActualWidth > System.Windows.SystemParameters.WorkArea.Width / 5 Then  ' BUG
            Label.TextWrapping = TextWrapping.Wrap
            Label.Width = System.Windows.SystemParameters.WorkArea.Width / 5
        End If

        CenterWindowOnScreen()
    End Sub

    Private Sub CenterWindowOnScreen()
        Dim screenWidth = System.Windows.SystemParameters.WorkArea.Width
        Dim screenHeight = System.Windows.SystemParameters.WorkArea.Height
        UpdateLayout()
        Dim windowWidth = Me.ActualWidth
        Dim windowHeight = Me.ActualHeight
        Me.Left = (screenWidth / 2) - (windowWidth / 2)
        Me.Top = (screenHeight / 2) - (windowHeight / 2)
    End Sub

#Region "window fades when closing. https://stackoverflow.com/questions/5958508/fading-out-a-window"
    Private AlreadyFaded As Boolean = False

    Private Sub window_Closing(ByVal sender As Object, ByVal e As CancelEventArgs) Handles Me.Closing
        If Not AlreadyFaded Then
            AlreadyFaded = True
            e.Cancel = True
            Dim anim = New DoubleAnimation(0, CType(TimeSpan.FromSeconds(0.2), Duration))
            AddHandler anim.Completed, New EventHandler(AddressOf anim_Completed)
            Me.BeginAnimation(UIElement.OpacityProperty, anim)
        End If
    End Sub

    Private Sub anim_Completed(ByVal sender As Object, ByVal e As EventArgs)
        Close()
    End Sub
#End Region

End Class
