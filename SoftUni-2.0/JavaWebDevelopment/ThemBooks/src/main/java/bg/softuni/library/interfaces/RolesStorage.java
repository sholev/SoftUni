package bg.softuni.library.interfaces;

import java.util.List;

public interface RolesStorage {
	
	List<String> getRoles();
	
	List<String> getRoles(Long id);

	boolean addRoles(Long userId, String... roles);
}
