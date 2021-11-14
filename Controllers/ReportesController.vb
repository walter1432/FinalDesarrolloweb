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
    Public Class ReportesController
        Inherits System.Web.Http.ApiController

        Private db As New Model1

        ' GET: api/Reportes
        Function GetReporte() As IQueryable(Of Reporte)
            Return db.Reporte
        End Function

        ' GET: api/Reportes/5
        <ResponseType(GetType(Reporte))>
        Function GetReporte(ByVal id As Integer) As IHttpActionResult
            Dim reporte As Reporte = db.Reporte.Find(id)
            If IsNothing(reporte) Then
                Return NotFound()
            End If

            Return Ok(reporte)
        End Function

        ' PUT: api/Reportes/5
        <ResponseType(GetType(Void))>
        Function PutReporte(ByVal id As Integer, ByVal reporte As Reporte) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            If Not id = reporte.Idreporte Then
                Return BadRequest()
            End If

            db.Entry(reporte).State = EntityState.Modified

            Try
                db.SaveChanges()
            Catch ex As DbUpdateConcurrencyException
                If Not (ReporteExists(id)) Then
                    Return NotFound()
                Else
                    Throw
                End If
            End Try

            Return StatusCode(HttpStatusCode.NoContent)
        End Function

        ' POST: api/Reportes
        <ResponseType(GetType(Reporte))>
        Function PostReporte(ByVal reporte As Reporte) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            db.Reporte.Add(reporte)
            db.SaveChanges()

            Return CreatedAtRoute("DefaultApi", New With {.id = reporte.Idreporte}, reporte)
        End Function

        ' DELETE: api/Reportes/5
        <ResponseType(GetType(Reporte))>
        Function DeleteReporte(ByVal id As Integer) As IHttpActionResult
            Dim reporte As Reporte = db.Reporte.Find(id)
            If IsNothing(reporte) Then
                Return NotFound()
            End If

            db.Reporte.Remove(reporte)
            db.SaveChanges()

            Return Ok(reporte)
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Function ReporteExists(ByVal id As Integer) As Boolean
            Return db.Reporte.Count(Function(e) e.Idreporte = id) > 0
        End Function
    End Class
End Namespace