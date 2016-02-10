package bg.softuni.ejb.interfaces;

public interface Accounting {
	
	String getAccountBallance(String owner);
	
	String Deposit(String owner, String amount);
	
	String Withdraw(String owner, String amount);	
}
