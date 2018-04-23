Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.Reflection

Namespace WindowsApplication1
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
			list = New BindingList(Of MyObject)()

			For i As Integer = 0 To 9
				list.Add(New MyObject(i.ToString()))
			Next i

			gridControl1.DataSource = list

		End Sub


		Private list As BindingList(Of MyObject)

		Private Sub simpleButton1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles simpleButton1.Click
			Using f As New XtraForm1(list)
				f.BindingContext = Me.BindingContext
				If f.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
					Dim cm As CurrencyManager = CType(Me.BindingContext(list), CurrencyManager)
					cm.EndCurrentEdit()
				End If
			End Using
		End Sub

	End Class

	Public Class MyObject
		Implements INotifyPropertyChanged
		Public Sub New(ByVal str As String)
			field_Renamed = str
		End Sub
		Private field_Renamed As String
		Public Property Field() As String
			Get
				Return field_Renamed
			End Get
			Set(ByVal value As String)
				field_Renamed = value
				NotifyPropertyChanged("Field")
			End Set
		End Property


		#Region "INotifyPropertyChanged Members"

		Private Sub NotifyPropertyChanged(ByVal info As String)
			RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(info))
		End Sub

		Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

		#End Region
	End Class
End Namespace