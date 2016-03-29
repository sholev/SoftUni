package bg.softuni.lebank.interfaces;

import java.util.Map;

import bg.softuni.lebank.dto.DisplayData;

public interface AccountsStorage {

	Boolean addAccount(String id, long accoungNo, String username, String amount, String currency, String createdBy);

	Boolean updateAccount(String accountId, String amount);

	DisplayData[] getAccountDisplayData(String[] accountIds);

	Map<String, AccountData> getAccounts();

	String[] getUserIds(String clientUsername);
	
	String[] getAllIds();
}