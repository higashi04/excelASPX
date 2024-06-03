const inputFechaInicio = document.getElementById("inputFechaInicio");
const inputFechaFin = document.getElementById("inputFechaFin");
const btnBusqueda = document.getElementById("btnBusqueda");
const btnDescargar = document.getElementById("btnDescargar");
const dataTable = document.getElementById("dataTable");
const bodyTablaResultados = document.getElementById("bodyTablaResultados");
const spanTextInfo = document.getElementById("spanTextInfo");
const resultsQty = document.getElementById("resultsQty");

const notFoundText = "No hay datos disponibles.";

const referenciasArray = [];

const construirCeldas = (text, row) => {
  const cell = document.createElement("td");
  cell.innerText = text;
  row.appendChild(cell);
};

const popularTabla = (operaciones) => {
  bodyTablaResultados.innerHTML = "";

  operaciones.map((operacion, opIndex) => {
    const row = document.createElement("tr");
    row.classList.add("table-row");
    const properties = Object.values(operacion);
    // console.log(properties);
    properties.forEach((prop, index) => {
      if (index === 0) {
        construirCeldas(opIndex + 1, row);
      } else {
        construirCeldas(prop, row);
        if (index === 4) {
          referenciasArray.push(prop);
        }
      }
    });
    console.log(referenciasArray);
    bodyTablaResultados.appendChild(row);
  });
};

const noResultsUI = () => {
  spanTextInfo.hidden = false;
  resultsQty.innerText = "0";
  if (spanTextInfo.classList.contains("notSearched")) {
    spanTextInfo.className = spanTextInfo.className.replace(
      "notSearched",
      "notFound"
    );
    spanTextInfo.innerText = notFoundText;
  }
};

const GetOperaciones = async () => {
  try {
    const data = {
      fechaIni: inputFechaInicio.value,
      fechaFin: inputFechaFin.value,
    };
    const response = await fetch("../Default.aspx/GetOperationsList", {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(data),
    });
    if (!response.ok) {
      throw response;
    }
    referenciasArray.length = 0;
    const json = await response.json();

    if (json.d.length > 0) {
      dataTable.hidden = false;
      resultsQty.innerText = json.d.length;
      popularTabla(json.d);
      spanTextInfo.hidden = true;
    } else {
      dataTable.hidden = true;
      bodyTablaResultados.innerHTML = "";
      noResultsUI();
    }
  } catch (error) {
    try {
      console.error(error);
      const err = await error.json();
      alert(err.Message);
    } catch (errorTwo) {
      console.error(errorTwo);
      alert(error);
    }
  }
};

const b64toBlob = (b64Data, contentType = "", sliceSize = 512) => {
  const byteCharacters = atob(b64Data);
  const byteArrays = [];

  for (let offset = 0; offset < byteCharacters.length; offset += sliceSize) {
    const slice = byteCharacters.slice(offset, offset + sliceSize);

    const byteNumbers = new Array(slice.length);
    for (let i = 0; i < slice.length; i++) {
      byteNumbers[i] = slice.charCodeAt(i);
    }

    const byteArray = new Uint8Array(byteNumbers);
    byteArrays.push(byteArray);
  }

  const blob = new Blob(byteArrays, { type: contentType });
  return blob;
};

const GetExcel = async () => {
  try {
    const data = {
      referencias: referenciasArray,
    };

    const response = await fetch("../Default.aspx/GetExcel", {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(data),
    });
    if (!response.ok) {
      throw response;
    }

    const json = await response.json();
    const downloadUrl = window.URL.createObjectURL(
      b64toBlob(
        json.d,
        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
      )
    );
    const anchor = document.createElement("a");
    anchor.style.display = "none";
    anchor.href = downloadUrl;
    anchor.download = "1716417755841.xls";
    document.body.appendChild(anchor);
    anchor.click();
    window.URL.revokeObjectURL(anchor);
  } catch (error) {
    try {
      console.error(error);
      const err = await error.json();
      alert(err.Message);
    } catch (errorTwo) {
      console.error(errorTwo);
      alert(error);
    }
  }
};

btnBusqueda.addEventListener("click", async () => {
  await GetOperaciones();
});

btnDescargar.addEventListener("click", async () => await GetExcel())
