package bg.softuni.library.dao.user;

import java.util.Set;
import java.util.TreeSet;
import java.util.stream.Collectors;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.TypedQuery;
import javax.persistence.criteria.CriteriaBuilder;
import javax.persistence.criteria.CriteriaQuery;
import javax.persistence.criteria.Predicate;
import javax.persistence.criteria.Root;

import org.hibernate.Criteria;
import org.hibernate.HibernateException;
import org.hibernate.Session;
import org.hibernate.SessionFactory;
import org.hibernate.Transaction;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;

import bg.softuni.library.dto.user.UserSearch;
import bg.softuni.library.entities.user.User;
import bg.softuni.library.interfaces.UsersStorage;

@Repository
public class UsersDao implements UsersStorage {

	@Autowired
	SessionFactory sessionFactory;

	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public Set<User> getUsers() {
		Set<User>users = new TreeSet<>();
		
		Criteria criteria = sessionFactory
				.openSession()
				.createCriteria(User.class);
		
		for (Object user : criteria.list()) {				
			users.add((User)user);
		}
	
		return users;
	}

//	@Override
//	public Set<User> getUsers(UserSearch search) {
//		Set<User>users = new TreeSet<>();
//		Map<String, String> restrictions = new HashMap<>();
//		
//		
//		Criteria criteria = sessionFactory
//				.openSession()
//				.createCriteria(User.class)
//				.add(Restrictions.and(
//						Restrictions.in("name", search.getName()),
//						Restrictions.in("username", search.getUsername()))
//						);
//				//.add(Restrictions.in("enabled", search.isEnabled()))
//				
//		
//		for (Object user : criteria.list()) {				
//			users.add((User)user);
//		}
//	
//		return users;
//	}
	
	@Override
	public Set<User> getUsers(UserSearch search) {
		CriteriaBuilder criteriaBuilder = entityManager.getCriteriaBuilder();
		CriteriaQuery<User> criteriaQuery = criteriaBuilder.createQuery(User.class);
		Root<User> from = criteriaQuery.from(User.class);

		Predicate predicate1 = criteriaBuilder.and();
		Predicate predicate2 = criteriaBuilder.and();
		Predicate predicate3 = criteriaBuilder.and();
		if (search.getName() != null && !search.getName().isEmpty()) {
			predicate1 = from.get("name").in(search.getName());
		}
		if (search.getUsername() != null && !search.getUsername().isEmpty()) {
			predicate2 = from.get("username").in(search.getUsername());
		}
		if (search.getStatus() != null && !search.getStatus().isEmpty()) {
			predicate3 = from.get("status").in(search.getStatus());
		}
		criteriaQuery.where(predicate1, predicate2, predicate3);

		criteriaQuery.select(from);
		TypedQuery<User> query = entityManager.createQuery(criteriaQuery);
		
		return query.getResultList().stream()
				.collect(Collectors.toCollection(() -> new TreeSet<User>()));
	}

	@Override
	public boolean addUser(User user) {		
		Transaction transaction = null;
		try (Session session = this.sessionFactory.openSession();) {			
			transaction = session.beginTransaction();
			
			session.save(user);
			
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

	@Override
	public boolean deactivateUser(Long userId) {		
		Transaction transaction = null;
		try (Session session = this.sessionFactory.openSession();) {			
			transaction = session.beginTransaction();
			
			User user = session.load(User.class, userId);
			user.setStatus("disabled");
			session.update(user);
			
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
}
