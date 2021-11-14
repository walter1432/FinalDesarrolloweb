Imports System
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity
Imports System.Linq

Partial Public Class Model1
    Inherits DbContext

    Public Sub New()
        MyBase.New("name=Model1")
    End Sub

    Public Overridable Property catedratico As DbSet(Of catedratico)
    Public Overridable Property Cursos As DbSet(Of Cursos)
    Public Overridable Property Reporte As DbSet(Of Reporte)

    Protected Overrides Sub OnModelCreating(ByVal modelBuilder As DbModelBuilder)
        modelBuilder.Entity(Of catedratico)() _
            .Property(Function(e) e.Nombre) _
            .IsUnicode(False)

        modelBuilder.Entity(Of catedratico)() _
            .Property(Function(e) e.Apellidos) _
            .IsUnicode(False)

        modelBuilder.Entity(Of catedratico)() _
            .Property(Function(e) e.Curso) _
            .IsUnicode(False)

        modelBuilder.Entity(Of Cursos)() _
            .Property(Function(e) e.NombreCurso) _
            .IsUnicode(False)

        modelBuilder.Entity(Of Reporte)() _
            .Property(Function(e) e.List_activo) _
            .IsUnicode(False)

        modelBuilder.Entity(Of Reporte)() _
            .Property(Function(e) e.List_aprobados) _
            .IsUnicode(False)

        modelBuilder.Entity(Of Reporte)() _
            .Property(Function(e) e.List_reprobado) _
            .IsUnicode(False)
    End Sub
End Class
