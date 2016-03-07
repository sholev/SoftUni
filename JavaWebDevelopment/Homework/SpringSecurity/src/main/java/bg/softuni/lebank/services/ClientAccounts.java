package bg.softuni.lebank.services;

import java.util.Collection;
import java.util.HashMap;
import java.util.HashSet;
import java.util.Map;
import java.util.Set;

import org.springframework.stereotype.Service;

import bg.softuni.lebank.constants.OutputMessages;
import bg.softuni.lebank.interfaces.UserAccounts;

@Service
public class ClientAccounts implements UserAccounts {
	
	Map<String, Set<String>> clientAccounts;
	
	public ClientAccounts() {
		this.clientAccounts = new HashMap<>();
	}
	
	@Override
	public String add(String clientUsername, String accountId) {
		if (!this.clientAccounts.containsKey(clientUsername)) {
			this.clientAccounts.put(clientUsername, new HashSet<String>());
		}
		
		if (this.clientAccounts.get(clientUsername).contains(accountId)) {
			return OutputMessages.INVALID_ACCOUNT_ALREADY_EXISTS(clientUsername, accountId);
		}
		
		this.clientAccounts.get(clientUsername).add(accountId);
		
		return OutputMessages.SUCCESSFULL_ACCOUNT_ADDITION;
	}
	
	@Override
	public String[] getUserIds(String clientUsername) {
		String[] output = null;		
		if (this.clientAccounts.containsKey(clientUsername)) {
			Set<String> ids = this.clientAccounts.get(clientUsername);
			output = ids.toArray(new String[ids.size()]);
		}
		
		return output;
	}
	
	@Override
	public String[] getAllIds() {
		String[] output = null;		
		if (!this.clientAccounts.isEmpty()) {
			Set<String> ids = new HashSet<String>();
			for (Set<String> idSet : this.clientAccounts.values()) {
				ids.addAll(idSet);
			}
			output = ids.toArray(new String[ids.size()]);
		}
		
		return output;
	}
}
