import React, { useContext } from 'react';
import { BrowserRouter, Switch, Route, Redirect } from 'react-router-dom';
import { Context } from './Context/AuthContext';
import Landing from './pages/Landing';
import Login from './pages/User/Login';
import User from './pages/User/CreateUser';
import CreateContact from './pages/Contact/CreateContact';
import Contact from './pages/Contact/Contact';
import Contacts from './pages/Contact/Contacts';
import Index from './pages/Contact/Index';
import Page404 from './pages/Page404';

// validação se o usuário pode acessar as rotas
function CustomRoute({isPrivate, ... rest} : any) {
    const { loading, authenticated } = useContext(Context);

    if (loading) {
        return <h1>Loading...</h1>;
      }
    
    if (isPrivate && !sessionStorage.getItem('token')) {
        return <Redirect to={{ pathname: "/login" }} />
      }
      else{
        return <Route {...rest} />;
      }
}

function Routes(){
    
    return(
        <BrowserRouter>
            <Switch>
                <CustomRoute path="/" exact component={Landing} />
                <CustomRoute path="/login" component={Login} />
                <CustomRoute path="/register" component={User} />
                <CustomRoute isPrivate path="/contact/home" exact component={Index} />
                <CustomRoute isPrivate path="/contact/create" exact component={CreateContact} />
                <CustomRoute isPrivate path="/contact/create/:id" exact component={Contact} />
                <CustomRoute isPrivate path="/contact/contacts" exact component={Contacts} />
                <CustomRoute path='/*' component={Page404} />
            </Switch>
        </BrowserRouter>
    );
}
export default Routes;