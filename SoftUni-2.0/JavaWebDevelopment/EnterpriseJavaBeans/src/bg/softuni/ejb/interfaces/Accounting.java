package bg.softuni.ejb.interfaces;

import javax.ejb.Local;

import bg.softuni.ejb.interfaces.CurrencyExchange;

@Local
public interface Accounting {
	
	String getAccountCurrency();
	
	String getAccountBallance(String owner);
	
	String deposit(String owner, String amount, String currency, CurrencyExchange rate);
	
	String withdraw(String owner, String amount,  String currency, CurrencyExchange rate);	
}
