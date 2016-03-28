package bg.softuni.lebank.interfaces;

import java.util.Map;

import bg.softuni.lebank.security.User;

public interface UsersStorage {

	Map<String, User> getUsers();

	String[] getUsernames();
	
}