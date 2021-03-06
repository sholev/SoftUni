package bg.softuni.lebank.interfaces;

public interface AccountsRepository {

	String getAccountCurrency(String accountId);
	
	String[] getMultipleAccountsCurrency(String[] accountIds);	
	
	String getAccountBalance(String accountId);
	
	String[] getMultipleAccountsBallance(String[] accountIds);	
	
	String deposit(String accountId, String amount, String currency);
	
	String withdraw(String accountId, String amount,  String currency);
}
