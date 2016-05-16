package bg.softuni.lebank.interfaces;

public interface OperationsStorage {

	Boolean addOperation(
			String id,
			long accoungNo,
			String operation,
			String amount,
			String currency,
			String performedBy);

}