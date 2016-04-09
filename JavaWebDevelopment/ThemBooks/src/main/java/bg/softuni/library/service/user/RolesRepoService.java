package bg.softuni.library.service.user;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import bg.softuni.library.interfaces.RolesService;
import bg.softuni.library.interfaces.RolesStorage;

@Service
public class RolesRepoService implements RolesService {
	
	@Autowired
	private RolesStorage rolesDao;
	
	@Override
	public List<String> getRoles() {		
		List<String> roles = rolesDao.getRoles();
		
		return roles;
	}

	@Override
	public List<String> getRoles(Long id) {
		List<String> roles = rolesDao.getRoles(id);
		
		return roles;
	}

	@Override
	public boolean addRoles(Long userId, String roles) {
		String[] rolesSplit = roles.split(", ");
		
		return rolesDao.addRoles(userId, rolesSplit);
	}

}
