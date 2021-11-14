Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("Reporte")>
Partial Public Class Reporte
    <Key>
    Public Property Idreporte As Integer

    <Required>
    <StringLength(50)>
    Public Property List_activo As String

    <Required>
    <StringLength(50)>
    Public Property List_aprobados As String

    <Required>
    <StringLength(50)>
    Public Property List_reprobado As String
End Class
