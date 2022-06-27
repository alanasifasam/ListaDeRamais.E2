const btnMenu = document.querySelector('#btnMenu');
const sidebar = document.querySelector('.sidebar');
const home = document.querySelector('.homeContent');
const Cards = document.querySelector('.Cards');
const main = document.querySelector('.main');
const toolipe = document.querySelector('.toolipe');
//EVENTOS DE click 
btnMenu.addEventListener('click', () => {
    sidebar.classList.toggle('active');
    home.classList.toggle('active');
    Cards.classList.toggle('active');
    main.classList.toggle('active');
    toolipe.classList.toggle('active');
});