#ExternalChecksum("..\..\MainWindow.xaml","{8829d00f-11b8-4213-878b-770e8597ac16}","D3F09148C0F87EF91A381AFCD133C1240F2FC7FCCC6397063AA5C28947EF4C23")
'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.42000
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports AALNEW
Imports System
Imports System.Diagnostics
Imports System.Windows
Imports System.Windows.Automation
Imports System.Windows.Controls
Imports System.Windows.Controls.Primitives
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Ink
Imports System.Windows.Input
Imports System.Windows.Markup
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Media.Effects
Imports System.Windows.Media.Imaging
Imports System.Windows.Media.Media3D
Imports System.Windows.Media.TextFormatting
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports System.Windows.Shell


'''<summary>
'''MainWindow
'''</summary>
<Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>  _
Partial Public Class MainWindow
    Inherits System.Windows.Window
    Implements System.Windows.Markup.IComponentConnector
    
    
    #ExternalSource("..\..\MainWindow.xaml",12)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents myMediaElement As System.Windows.Controls.MediaElement
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\MainWindow.xaml",18)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents timelineSlider As System.Windows.Controls.Slider
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\MainWindow.xaml",35)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents volumeSlider As System.Windows.Controls.Slider
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\MainWindow.xaml",40)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents speedRatioSlider As System.Windows.Controls.Slider
    
    #End ExternalSource
    
    Private _contentLoaded As Boolean
    
    '''<summary>
    '''InitializeComponent
    '''</summary>
    <System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")>  _
    Public Sub InitializeComponent() Implements System.Windows.Markup.IComponentConnector.InitializeComponent
        If _contentLoaded Then
            Return
        End If
        _contentLoaded = true
        Dim resourceLocater As System.Uri = New System.Uri("/AALNEW;component/mainwindow.xaml", System.UriKind.Relative)
        
        #ExternalSource("..\..\MainWindow.xaml",1)
        System.Windows.Application.LoadComponent(Me, resourceLocater)
        
        #End ExternalSource
    End Sub
    
    <System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0"),  _
     System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never),  _
     System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes"),  _
     System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity"),  _
     System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")>  _
    Sub System_Windows_Markup_IComponentConnector_Connect(ByVal connectionId As Integer, ByVal target As Object) Implements System.Windows.Markup.IComponentConnector.Connect
        If (connectionId = 1) Then
            
            #ExternalSource("..\..\MainWindow.xaml",8)
            AddHandler CType(target,MainWindow).Loaded, New System.Windows.RoutedEventHandler(AddressOf Me.Window_Loaded)
            
            #End ExternalSource
            Return
        End If
        If (connectionId = 2) Then
            Me.myMediaElement = CType(target,System.Windows.Controls.MediaElement)
            Return
        End If
        If (connectionId = 3) Then
            Me.timelineSlider = CType(target,System.Windows.Controls.Slider)
            
            #ExternalSource("..\..\MainWindow.xaml",18)
            AddHandler Me.timelineSlider.ValueChanged, New System.Windows.RoutedPropertyChangedEventHandler(Of Double)(AddressOf Me.SeekToMediaPosition)
            
            #End ExternalSource
            Return
        End If
        If (connectionId = 4) Then
            
            #ExternalSource("..\..\MainWindow.xaml",25)
            AddHandler CType(target,System.Windows.Controls.Image).MouseDown, New System.Windows.Input.MouseButtonEventHandler(AddressOf Me.OnMouseDownPlayMedia)
            
            #End ExternalSource
            Return
        End If
        If (connectionId = 5) Then
            
            #ExternalSource("..\..\MainWindow.xaml",28)
            AddHandler CType(target,System.Windows.Controls.Image).MouseDown, New System.Windows.Input.MouseButtonEventHandler(AddressOf Me.OnMouseDownPauseMedia)
            
            #End ExternalSource
            Return
        End If
        If (connectionId = 6) Then
            
            #ExternalSource("..\..\MainWindow.xaml",31)
            AddHandler CType(target,System.Windows.Controls.Image).MouseDown, New System.Windows.Input.MouseButtonEventHandler(AddressOf Me.OnMouseDownStopMedia)
            
            #End ExternalSource
            Return
        End If
        If (connectionId = 7) Then
            Me.volumeSlider = CType(target,System.Windows.Controls.Slider)
            
            #ExternalSource("..\..\MainWindow.xaml",35)
            AddHandler Me.volumeSlider.ValueChanged, New System.Windows.RoutedPropertyChangedEventHandler(Of Double)(AddressOf Me.ChangeMediaVolume)
            
            #End ExternalSource
            Return
        End If
        If (connectionId = 8) Then
            Me.speedRatioSlider = CType(target,System.Windows.Controls.Slider)
            
            #ExternalSource("..\..\MainWindow.xaml",40)
            AddHandler Me.speedRatioSlider.ValueChanged, New System.Windows.RoutedPropertyChangedEventHandler(Of Double)(AddressOf Me.ChangeMediaSpeedRatio)
            
            #End ExternalSource
            Return
        End If
        Me._contentLoaded = true
    End Sub
End Class

