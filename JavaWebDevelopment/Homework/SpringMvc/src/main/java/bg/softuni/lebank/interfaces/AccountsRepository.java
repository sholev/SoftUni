package bg.softuni.lebank.interfaces;

public interface AccountsRepository {
	
	String getAccountCurrency();
	
	String getAccountBallance(String owner);
	
	String deposit(String owner, String amount, String currency, CurrencyExchange rate);
	
	String withdraw(String owner, String amount,  String currency, CurrencyExchange rate);	
}
