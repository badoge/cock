let cocks = 0;
document.getElementById("cock").addEventListener("click", dank);
document.addEventListener("contextmenu", (event) => event.preventDefault());

function dank() {
  cocks++;
  document.getElementById("cocks").innerHTML = cocks.toLocaleString();
}
