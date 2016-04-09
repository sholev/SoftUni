package bg.softuni.library.service.user;

import java.util.Set;
import java.util.stream.Collectors;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import bg.softuni.library.dto.user.UserSearch;
import bg.softuni.library.entity.user.User;
import bg.softuni.library.interfaces.RolesService;
import bg.softuni.library.interfaces.UsersService;
import bg.softuni.library.interfaces.UsersStorage;
import bg.softuni.library.util.SecurityUtil;

@Service
public class UsersRepoService implements UsersService {

	@Autowired
	private UsersStorage usersDao;
	
	@Autowired
	private RolesService rolesService;
	
	@Override
	public Set<User> getUsers() {
		Set<User> result = usersDao.getUsers();
		
		for(User user : result) {
			Long userId = user.getId();
			user.setRoles(String.join(", ", rolesService.getRoles(userId)));
		}
		
		return result;
	}
	
	@Override
	public Set<User> getUsers(UserSearch search) {
		Set<User> result = usersDao.getUsers(search);
		
		for(User user : result) {
			Long userId = user.getId();
			user.setRoles(String.join(", ", rolesService.getRoles(userId)));
		}
		
		return result;
	}
	
	@Override
	public Set<String> getUsernames() {
		
		Set<String> usernames = usersDao.getUsers()
				.stream()
				.map(User::getUsername)
				.collect(Collectors.toSet());
		
		return usernames;
	}
	
	@Override
	public boolean addUser(User user) {
		user.setStatus("enabled");
		user.setPassword(SecurityUtil.getMd5FromString(user.getPassword()));
		
		boolean addUserSuccessful = usersDao.addUser(user);
		boolean addRolesSuccessful = false;
		if (addUserSuccessful) {
			addRolesSuccessful = rolesService.addRoles(user.getId(), user.getRoles());
		}
		
		return  addUserSuccessful && addRolesSuccessful;
	}

	@Override
	public boolean deactivateUser(User user) {		
		return usersDao.deactivateUser(user.getId());
	}
}