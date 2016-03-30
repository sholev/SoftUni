package bg.softuni.lebank.interfaces;

import java.util.Map;

import bg.softuni.lebank.security.SecurityUser;

public interface UserStorage {

	Map<String, SecurityUser> getUsers();

	String[] getUsernames();
	
}