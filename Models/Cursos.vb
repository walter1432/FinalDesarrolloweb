Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class Cursos
    Public Property Id As Integer

    <Required>
    <StringLength(50)>
    Public Property NombreCurso As String
End Class
