using PojistovnaWebApp.Data;
using PojistovnaWebApp.Models;
using EntityFrameworkCore.Triggered;
using Microsoft.EntityFrameworkCore;
/*
 * "Before safe" trigger pro pojistnou událost
 * Trigger ověřuje, zda plnění pojištění "Plneni" v pojistné události není větší než pojištěná částka ve sjednaném pojištění.
 * Pokud je plnění větší než pojištěná částka, trigger uloží změny do databáze. Pokud tomu tak není, trigger se nespustí a změny se neuloží.
 */
namespace PojistovnaWebApp.Triggers
{

}

