<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
	<head>
		<meta charset="UTF-8">
		<title>Spring banking page</title>
	</head>
	<body>
		<form action="/lebank/" method="POST">
		
			${output} <br>
			Client ID: 
			<input type="text" name="clientId" value="${clientId}"> <br>
			${currentBallance} <br>		
			Operation: 
			<input type="radio" name="selectedOperation" value="deposit">Deposit
			<input type="radio" name="selectedOperation" value="withdraw">Withdraw
			<br>
			Amount: <input type="number" name="operationAmount" value="0">
			<select name="selectedCurrency">
				<option value="USD">USD</option>
				<option value="EUR">EUR</option>
				<option value="GBP">GBP</option>
				<option value="BGN">BGN</option>
			</select>
			<input type="submit" value="Submit">	
		</form>
		<br><br>
		<div id="footer">		
		${serverTime}<br>
		${project} <br>
		${version}
		</div>
	</body>
</html>