const body = document.querySelector('body'),
    sidebar = body.querySelector('nav'),
    toggle = body.querySelector(".toggle"),
    searchBtn = body.querySelector(".search-box"),
    modeSwitch = body.querySelector(".toggle-switch"),
    modeText = body.querySelector(".mode-text"),
    modeImg = body.querySelector(".mode-img"),
    tooltipElements = document.querySelectorAll('[data-bs-toggle="tooltip"]');

let tooltipInstances = Array.from(tooltipElements).map(element => new bootstrap.Tooltip(element));

toggle.addEventListener("click", () => {
    sidebar.classList.toggle("hide");

    if (sidebar.classList.contains("hide")) {
        tooltipInstances.forEach(instance => instance.dispose()); // Remove todas as instâncias de tooltips
    } else {
        tooltipInstances = Array.from(tooltipElements).map(element => new bootstrap.Tooltip(element)); // Recria todas as instâncias de tooltips
    }
});

toggle.addEventListener("click", () => {
    sidebar.classList.toggle("close");
});

searchBtn.addEventListener("click", () => {
    sidebar.classList.remove("close");
    tooltipInstances = Array.from(tooltipElements).map(element => new bootstrap.Tooltip(element)); // Recria todas as instâncias de tooltips
});

modeSwitch.addEventListener("click", () => {
    body.classList.toggle("dark");

    if (body.classList.contains("dark")) {
        modeText.innerText = "Modo Claro";
        modeImg.innerHTML = '<img src="lib/IMG/LOGOMENOR2.png" width="190" />';
    } else {
        modeText.innerText = "Modo Escuro";
        modeImg.innerHTML = '<img src="lib/IMG/logobottom.png" width="190" />';
    }
});
