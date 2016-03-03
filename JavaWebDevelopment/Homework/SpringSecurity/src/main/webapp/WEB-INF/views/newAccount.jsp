<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
	<head>
		<meta charset="UTF-8">
		<title>Account Creation</title>
	</head>
	<body>
		<form action="/lebank/createAccount" method="POST">
			${output} <br>
			<table>
				<tr>
					<td>Account Number: </td>
					<td><input type="text" name="accountNumber" value="${accountNumber}"></td>
				</tr>
				<tr>
					<td>Initial Ballance: </td>
					<td><input type="number" name="accountBallance" value="${accountBallance}"></td>
				</tr>
				<tr>
					<td>Account Currency: </td>
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
		</form>
	</body>
</html>