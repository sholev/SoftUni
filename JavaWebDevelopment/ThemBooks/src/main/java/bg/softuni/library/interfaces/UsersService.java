package bg.softuni.library.interfaces;

import java.util.Set;

import bg.softuni.library.dto.user.UserSearch;
import bg.softuni.library.entities.user.User;

public interface UsersService {
	
	Set<User> getUsers();
	
	Set<User> getUsers(UserSearch userSearch);
	
	Set<String> getUsernames();

	boolean addUser(User user);

	boolean deactivateUser(User user);
}
