<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
	<head>
		<meta charset="UTF-8">
		<title>Banking Operation</title>
	</head>
	<body>
		<form action="/lebank/makeOperation" method="POST">
			${output} <br>
			<table>
				<tr>
					<td>Account Number: </td>
					<td><input type="text" name="accountNumber" value="${accountNumber}"></td>
				</tr>
				<tr>
					<td>Operation: </td>
					<td>
						<input type="radio" name="selectedOperation" value="deposit">Deposit
						<input type="radio" name="selectedOperation" value="withdraw">Withdraw
					</td>
				</tr>
				<tr>
					<td>Amount: </td>
					<td><input type="text" name="operationAmmount" value="${operationAmmount}"></td>
				</tr>
				<tr>
					<td>Currency: </td>
					<td>
						<select name="selectedCurrency">
							<option value="USD">USD</option>
							<option value="EUR">EUR</option>
							<option value="GBP">GBP</option>
							<option value="BGN">BGN</option>
						</select>
					</td>
				</tr>			
			</table>
			<input type="submit" value="Submit">
			<input type="submit" value="Back" formaction="/lebank/">
		</form>
	</body>
</html>