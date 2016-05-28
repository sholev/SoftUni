package bg.softuni.lebank.interfaces;

public interface AccountService {

	String getAccountCurrency(String accountId);
	
	String[] getMultipleAccountsCurrency(String[] accountIds);	
	
	String getAccountBalance(String accountId);
	
	String[] getMultipleAccountsBallance(String[] accountIds);	
	
	String deposit(String accountId, String amount, String currency, String currentUser);
	
	String withdraw(String accountId, String amount, String currency, String currentUser);
}
