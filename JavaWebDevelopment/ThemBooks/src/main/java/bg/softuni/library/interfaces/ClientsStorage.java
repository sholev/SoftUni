package bg.softuni.library.interfaces;

import java.util.Set;

import bg.softuni.library.entities.client.Client;

public interface ClientsStorage {
	
	Set<Client> getClients();
	
	Set<Client> getClients(Client search);

	boolean addClient(Client client);

	boolean deleteClient(Client client);

	boolean editClient(Long clientId, Client updatedClient);
}
