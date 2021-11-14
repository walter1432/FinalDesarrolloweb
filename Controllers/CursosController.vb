Imports System.Data
Imports System.Data.Entity
Imports System.Data.Entity.Infrastructure
Imports System.Linq
Imports System.Net
Imports System.Net.Http
Imports System.Web.Http
Imports System.Web.Http.Description
Imports FinalDesarrollo

Namespace Controllers
    Public Class CursosController
        Inherits System.Web.Http.ApiController

        Private db As New Model1

        ' GET: api/Cursos
        Function GetCursos() As IQueryable(Of Cursos)
            Return db.Cursos
        End Function

        ' GET: api/Cursos/5
        <ResponseType(GetType(Cursos))>
        Function GetCursos(ByVal id As Integer) As IHttpActionResult
            Dim cursos As Cursos = db.Cursos.Find(id)
            If IsNothing(cursos) Then
                Return NotFound()
            End If

            Return Ok(cursos)
        End Function

        ' PUT: api/Cursos/5
        <ResponseType(GetType(Void))>
        Function PutCursos(ByVal id As Integer, ByVal cursos As Cursos) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            If Not id = cursos.Id Then
                Return BadRequest()
            End If

            db.Entry(cursos).State = EntityState.Modified

            Try
                db.SaveChanges()
            Catch ex As DbUpdateConcurrencyException
                If Not (CursosExists(id)) Then
                    Return NotFound()
                Else
                    Throw
                End If
            End Try

            Return StatusCode(HttpStatusCode.NoContent)
        End Function

        ' POST: api/Cursos
        <ResponseType(GetType(Cursos))>
        Function PostCursos(ByVal cursos As Cursos) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            db.Cursos.Add(cursos)
            db.SaveChanges()

            Return CreatedAtRoute("DefaultApi", New With {.id = cursos.Id}, cursos)
        End Function

        ' DELETE: api/Cursos/5
        <ResponseType(GetType(Cursos))>
        Function DeleteCursos(ByVal id As Integer) As IHttpActionResult
            Dim cursos As Cursos = db.Cursos.Find(id)
            If IsNothing(cursos) Then
                Return NotFound()
            End If

            db.Cursos.Remove(cursos)
            db.SaveChanges()

            Return Ok(cursos)
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Function CursosExists(ByVal id As Integer) As Boolean
            Return db.Cursos.Count(Function(e) e.Id = id) > 0
        End Function
    End Class
End Namespace