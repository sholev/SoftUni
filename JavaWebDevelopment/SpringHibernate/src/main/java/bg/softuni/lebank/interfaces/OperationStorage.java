package bg.softuni.lebank.interfaces;

import bg.softuni.lebank.entities.DatabaseOperation;

public interface OperationStorage {

	Boolean addOperation(DatabaseOperation operationData);

}