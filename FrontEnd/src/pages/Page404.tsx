import React from 'react';
import '../styles/Pages/Page404.css';
import logoImg from '../images/user-male.png';

function Page404(){
    return(
        <div id="page404">
            <div className="content-wrapper">
                <img src={logoImg} alt="App"></img>
                <main>
                <div className="title"><h1>404</h1></div>
                <div className="message"><p>Ops... A página que você está procurando não existe ou é inacessível!</p></div>
                </main>
            </div>
        </div>
    );
}

export default Page404;