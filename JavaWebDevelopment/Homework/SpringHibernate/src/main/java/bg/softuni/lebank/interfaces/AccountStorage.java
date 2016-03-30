package bg.softuni.lebank.interfaces;

import java.util.List;
import java.util.Map;

import bg.softuni.lebank.entities.DatabaseAccount;
import bg.softuni.lebank.entities.DisplayData;

public interface AccountStorage {

	Boolean addAccount(DatabaseAccount accountData);

	Boolean updateAccount(String accountId, String amount);

	List<DisplayData> getAccountDisplayData(List<String> accountIds);

	Map<String, AccountData> getAccounts();

	List<String> getUserIds(String clientUsername);
	
	List<String> getAllIds();
}