<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
	<head>
		<meta charset="UTF-8">
		<title>Spring banking page</title>
	</head>
	<body>
		<form action="/lebank/" method="POST">
		
			<%=request.getAttribute("output") == null ? "" : request.getAttribute("output") + "<br>"%>
			Client ID: 
			<input type="text" name="clientId" value="<%=request.getAttribute("clientId") == null ? "" : request.getAttribute("clientId")%>">
			<%=request.getAttribute("currentBallance") == null ? "" : "<br>Client balance: " + request.getAttribute("currentBallance") + " BGN"%>
			<br>		
			Operation: 
			<input type="radio" name="selectedOperation" value="deposit">Deposit
			<input type="radio" name="selectedOperation" value="withdraw">Withdraw
			<br>
			Amount: <input type="number" name="operationAmount" value="0">
			<select name="selectedCurrency">
				<option value="usd">USD</option>
				<option value="eur">EUR</option>
				<option value="gbp">GPB</option>
				<option value="bgn">BGN</option>
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