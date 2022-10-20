//interface do model Contato para paginação
import { Contato } from "./IContact";

export interface ContactPage {
    pagina: Number;
    contato: Contato;
 }