let cocks = 0;
document.getElementById("cock").addEventListener("click", dank);
function dank() {
  cocks++;
  document.getElementById("cocks").innerHTML = cocks.toLocaleString();
}
