package bg.softuni.lebank.interfaces;

public interface UserAccounts {

	String add(String clientUsername, String accountId);

	String[] getUserIds(String clientUsername);
	
	String[] getAllIds();
}