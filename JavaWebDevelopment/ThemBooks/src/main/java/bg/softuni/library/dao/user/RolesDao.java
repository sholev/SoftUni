package bg.softuni.library.dao.user;

import java.util.List;
import java.util.ArrayList;

import org.hibernate.Criteria;
import org.hibernate.HibernateException;
import org.hibernate.Session;
import org.hibernate.SessionFactory;
import org.hibernate.Transaction;
import org.hibernate.criterion.Order;
import org.hibernate.criterion.Restrictions;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;

import bg.softuni.library.entities.user.Role;
import bg.softuni.library.interfaces.RolesStorage;

@Repository
public class RolesDao implements RolesStorage {

	@Autowired
	SessionFactory sessionFactory;
	
	@Override
	public List<String> getRoles() {
		List<String> result = new ArrayList<>();
		
		Criteria criteria = sessionFactory
				.openSession()
				.createCriteria(Role.class);
		
		for (Object role : criteria.list()) {				
			Role userRole = (Role)role;
						
			result.add(userRole.getRole());
		}
		
		return result;
	}
	
	@Override
	public List<String> getRoles(Long id) {
		List<String> result = new ArrayList<>();
		
		Criteria criteria = sessionFactory
				.openSession()
				.createCriteria(Role.class)
				.add(Restrictions.eq("userId", id));
		
		for (Object role : criteria.list()) {				
			Role userRole = (Role)role;
						
			result.add(userRole.getRole());
		}
		
		return result;
	}

	@Override
	public boolean addRoles(Long userId, String... roles) {
		Long lastId = getMaxId();
		
		Transaction transaction = null;
		try (Session session = this.sessionFactory.openSession();) {			
			transaction = session.beginTransaction();

			for(String role : roles) {
				lastId++;
				Role newRole = new Role(lastId, userId, role);
				session.save(newRole);
			}
			transaction.commit();
			
		} catch (HibernateException e) {
			if (transaction != null) {
				transaction.rollback();
			}
			e.printStackTrace();
			
			return false;
		}
		return true;	
	}
	
	private Long getMaxId() {		
		Object lastEntry = sessionFactory
				.openSession()
				.createCriteria(Role.class)
				.addOrder(Order.desc("id"))
				.setMaxResults(1)
				.uniqueResult();
		
		return ((Role)lastEntry).getId();
	}
}
