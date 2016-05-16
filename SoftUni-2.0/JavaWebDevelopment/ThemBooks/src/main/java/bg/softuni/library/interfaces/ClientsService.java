package bg.softuni.library.interfaces;

import java.util.Set;

import bg.softuni.library.entity.client.Client;

public interface ClientsService {

	Set<Client> getClients();
	
	Set<Client> getClients(Client client);

	boolean addClient(Client client);
	
	boolean deleteClient(Client client);

	boolean editClient(Client client);
}