Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("catedratico")>
Partial Public Class catedratico
    Public Property Id As Integer

    <Required>
    <StringLength(50)>
    Public Property Nombre As String

    <Required>
    <StringLength(50)>
    Public Property Apellidos As String

    <Required>
    <StringLength(50)>
    Public Property Curso As String
End Class
