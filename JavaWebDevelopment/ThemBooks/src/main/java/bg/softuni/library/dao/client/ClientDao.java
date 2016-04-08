package bg.softuni.library.dao.client;

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

import bg.softuni.library.entities.client.Client;
import bg.softuni.library.interfaces.ClientsStorage;

@Repository
public class ClientDao implements ClientsStorage {

	@Autowired
	SessionFactory sessionFactory;

	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public Set<Client> getClients() {
		Set<Client> clients = new TreeSet<>();
		
		Criteria criteria = sessionFactory
				.openSession()
				.createCriteria(Client.class);
		
		for (Object user : criteria.list()) {				
			clients.add((Client)user);
		}
	
		return clients;
	}

	@Override
	public Set<Client> getClients(Client search) {
		CriteriaBuilder criteriaBuilder = entityManager.getCriteriaBuilder();
		CriteriaQuery<Client> criteriaQuery = criteriaBuilder.createQuery(Client.class);
		Root<Client> from = criteriaQuery.from(Client.class);

		Predicate predicate1 = criteriaBuilder.and();
		Predicate predicate2 = criteriaBuilder.and();
		Predicate predicate3 = criteriaBuilder.and();
		if (search.getName() != null && !search.getName().isEmpty()) {
			predicate1 = from.get("name").in(search.getName());
		}
		if (search.getPid() != null && !search.getPid().isEmpty()) {
			predicate2 = from.get("pid").in(search.getPid() );
		}
		if (search.getBirthDate() != null) {
			predicate3 = from.get("birthDate").in(search.getBirthDate());
		}
		criteriaQuery.where(predicate1, predicate2, predicate3);

		criteriaQuery.select(from);
		TypedQuery<Client> query = entityManager.createQuery(criteriaQuery);
		
		return query.getResultList().stream()
				.collect(Collectors.toCollection(() -> new TreeSet<Client>()));
	}

	@Override
	public boolean addClient(Client client) {
		Transaction transaction = null;
		try (Session session = this.sessionFactory.openSession();) {			
			transaction = session.beginTransaction();
			
			session.save(client);
			
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
	public boolean deleteClient(Client client) {
		Transaction transaction = null;
		try (Session session = this.sessionFactory.openSession();) {			
			transaction = session.beginTransaction();
			
			session.delete(client);
			
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
	public boolean editClient(Long clientId, Client updatedClient) {
		Transaction transaction = null;
		try (Session session = this.sessionFactory.openSession();) {			
			transaction = session.beginTransaction();
			
			Client client = session.load(Client.class, clientId);
			client = updatedClient;
			session.update(client);
			
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
