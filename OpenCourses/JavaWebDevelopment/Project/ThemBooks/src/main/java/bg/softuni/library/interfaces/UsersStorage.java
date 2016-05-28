package bg.softuni.library.interfaces;

import java.util.Set;

import bg.softuni.library.dto.user.UserSearch;
import bg.softuni.library.entity.user.User;

public interface UsersStorage {

	Set<User> getUsers();
	
	Set<User> getUsers(UserSearch search);

	boolean addUser(User user);

	boolean deactivateUser(Long userId);
}