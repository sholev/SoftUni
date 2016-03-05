package bg.softuni.lebank.services;

import java.util.HashMap;
import java.util.HashSet;
import java.util.Map;
import java.util.Set;

import org.springframework.stereotype.Service;

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
			return clientUsername + " already contains account with id: " + accountId;
		}
		
		this.clientAccounts.get(clientUsername).add(accountId);
		
		return "Sccessfuly added new accound for client username.";
	}
	
	// TODO: remove method.
	
	@Override
	public String[] getIds(String clientUsername) {
		String[] output = null;		
		if (this.clientAccounts.containsKey(clientUsername)) {
			Set<String> ids = this.clientAccounts.get(clientUsername);
			output = ids.toArray(new String[ids.size()]);
		}
		
		return output;
	}
	
	@Override
	public String getId(String clientUsername, int index) {
		return this.getIds(clientUsername)[index];
	}
	
	@Override
	public String getLastId(String clientUsername) {
		String[] ids = this.getIds(clientUsername);
		int lastIndex = ids.length - 1;
		return ids[lastIndex];
	}
}
