package bg.softuni.lebank.interfaces;

import java.util.Map;

import bg.softuni.lebank.security.User;

public interface Users {

	Map<String, User> getUsers();

	String[] getUsernames();

}