package bg.softuni.library.services.client;

import java.util.Set;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import bg.softuni.library.entities.client.Client;
import bg.softuni.library.interfaces.ClientsService;
import bg.softuni.library.interfaces.ClientsStorage;

@Service
public class ClientsRepositoryService implements ClientsService {

	@Autowired
	private ClientsStorage cientsDao;

	@Override
	public Set<Client> getClients(Client search) {
		Set<Client> result = this.cientsDao.getClients(search);
		
		return result;
	}

	@Override
	public boolean addClient(Client client) {
		return cientsDao.addClient(client);
	}

	@Override
	public boolean deleteClient(Client client) {
		return cientsDao.deleteClient(client);
	}

	@Override
	public boolean editClient(Client client) {
		Long clientId = client.getId();
		
		return cientsDao.editClient(clientId, client);
	}	
}
