<%@ Page Title="Monitor Buckland" Language="C#" MasterPageFile="~/Site.Master"
AutoEventWireup="true" CodeBehind="Default.aspx.cs"
Inherits="excelASPX._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
  <main>
    <h1 class="mx-3">Monitor Buckland</h1>
    <div id="dataMain" class="mx-3" >
      <div id="divBusquedaDatos" class="row">
        <div class="col-6">
          <div class="row">
            <div class="col-4">
                Fecha Inicio:
                <div class="input-group">
                    <input type="date" id="inputFechaInicio" class="form-control" />
                </div>
            </div>
            <div class="col-4">
                Fecha Fin:
                <div class="input-group">
                    <input type="date" id="inputFechaFin" class="form-control" />
                </div> 
            </div>
            <div class="col-4">
                <div class="form-check form-switch">
                    <input class="form-check-input" type="checkbox" role="switch" id="switchUpdate">
                    <label class="form-check-label" for="switchUpdate">Auto Update</label>
                  </div>
            </div>
          </div>
        </div>
        <div id="btnsBusqueda" class="col-6">
          <button id="btnBusqueda" class="btn btn-outline-primary mx-3" type="button">
            <svg
              xmlns="http://www.w3.org/2000/svg"
              width="24"
              height="24"
              fill="currentColor"
              class="bi bi-search"
              viewBox="0 0 16 16"
            >
              <path
                d="M11.742 10.344a6.5 6.5 0 1 0-1.397 1.398h-.001q.044.06.098.115l3.85 3.85a1 1 0 0 0 1.415-1.414l-3.85-3.85a1 1 0 0 0-.115-.1zM12 6.5a5.5 5.5 0 1 1-11 0 5.5 5.5 0 0 1 11 0"
              />
            </svg>
            Buscar
          </button>
          <button id="btnDescargar" class="btn btn-outline-primary mx-3" type="button">
            <svg
              xmlns="http://www.w3.org/2000/svg"
              width="24"
              height="24"
              fill="currentColor"
              class="bi bi-cloud-arrow-down"
              viewBox="0 0 16 16"
            >
              <path
                fill-rule="evenodd"
                d="M7.646 10.854a.5.5 0 0 0 .708 0l2-2a.5.5 0 0 0-.708-.708L8.5 9.293V5.5a.5.5 0 0 0-1 0v3.793L6.354 8.146a.5.5 0 1 0-.708.708z"
              />
              <path
                d="M4.406 3.342A5.53 5.53 0 0 1 8 2c2.69 0 4.923 2 5.166 4.579C14.758 6.804 16 8.137 16 9.773 16 11.569 14.502 13 12.687 13H3.781C1.708 13 0 11.366 0 9.318c0-1.763 1.266-3.223 2.942-3.593.143-.863.698-1.723 1.464-2.383m.653.757c-.757.653-1.153 1.44-1.153 2.056v.448l-.445.049C2.064 6.805 1 7.952 1 9.318 1 10.785 2.23 12 3.781 12h8.906C13.98 12 15 10.988 15 9.773c0-1.216-1.02-2.228-2.313-2.228h-.5v-.5C12.188 4.825 10.328 3 8 3a4.53 4.53 0 0 0-2.941 1.1z"
              />
            </svg>
            Descargar
          </button>
        </div>
      </div>
      <hr />
      <div class="row my-3">
        <span id="spanTextInfo" class="notSearched"> Aplique los filtros requeridos y haga click en buscar. </span>
      </div>
      <div id="dataTable" class="row" hidden>
        <table class="table">
            <thead>
                <tr>
                    <th scope="col">#</th>
                    <th scope="col">Cliente</th>
                    <th scope="col">Clave Pedimento</th>
                    <th scope="col">Tipo Operacion</th>
                    <th scope="col">Referencia</th>
                    <th scope="col">Pedimento</th>
                    <th scope="col">Remesa</th>
                    <th scope="col">Caja</th>
                    <th scope="col">Sello</th>
                    <th scope="col">Doda</th>
                    <th scope="col">CP <br/> Folios</th>
                    <th scope="col">Cruce / SOIA</th>
                    <th scope="col">Usuario</th>
                    <th scope="col">Tiempo Recibo BGTS</th>
                    <th scope="col">Tiempo ACG Confirmado</th>
                    <th scope="col">Fecha CCP</th>
                    <th scope="col">Fecha de Remesa</th>
                </tr>
            </thead>
            <tbody id="bodyTablaResultados"></tbody>
        </table>
      </div>
      <div class="row">
       <div class="col">
        Registros: <span id="resultsQty">0</span>
       </div>
      </div>
    </div>
  </main>
</asp:Content>
