package bg.softuni.lebank.interfaces;

public interface UserAccounts {

	String add(String clientUsername, String accountId);

	String[] getIds(String clientUsername);

	String getId(String clientUsername, int index);

	String getLastId(String clientUsername);
}