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
    Public Class catedraticoesController
        Inherits System.Web.Http.ApiController

        Private db As New Model1

        ' GET: api/catedraticoes
        Function Getcatedratico() As IQueryable(Of catedratico)
            Return db.catedratico
        End Function

        ' GET: api/catedraticoes/5
        <ResponseType(GetType(catedratico))>
        Function Getcatedratico(ByVal id As Integer) As IHttpActionResult
            Dim catedratico As catedratico = db.catedratico.Find(id)
            If IsNothing(catedratico) Then
                Return NotFound()
            End If

            Return Ok(catedratico)
        End Function

        ' PUT: api/catedraticoes/5
        <ResponseType(GetType(Void))>
        Function Putcatedratico(ByVal id As Integer, ByVal catedratico As catedratico) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            If Not id = catedratico.Id Then
                Return BadRequest()
            End If

            db.Entry(catedratico).State = EntityState.Modified

            Try
                db.SaveChanges()
            Catch ex As DbUpdateConcurrencyException
                If Not (catedraticoExists(id)) Then
                    Return NotFound()
                Else
                    Throw
                End If
            End Try

            Return StatusCode(HttpStatusCode.NoContent)
        End Function

        ' POST: api/catedraticoes
        <ResponseType(GetType(catedratico))>
        Function Postcatedratico(ByVal catedratico As catedratico) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            db.catedratico.Add(catedratico)
            db.SaveChanges()

            Return CreatedAtRoute("DefaultApi", New With {.id = catedratico.Id}, catedratico)
        End Function

        ' DELETE: api/catedraticoes/5
        <ResponseType(GetType(catedratico))>
        Function Deletecatedratico(ByVal id As Integer) As IHttpActionResult
            Dim catedratico As catedratico = db.catedratico.Find(id)
            If IsNothing(catedratico) Then
                Return NotFound()
            End If

            db.catedratico.Remove(catedratico)
            db.SaveChanges()

            Return Ok(catedratico)
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Function catedraticoExists(ByVal id As Integer) As Boolean
            Return db.catedratico.Count(Function(e) e.Id = id) > 0
        End Function
    End Class
End Namespace