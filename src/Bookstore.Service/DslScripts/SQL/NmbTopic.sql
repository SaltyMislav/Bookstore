SELECT
	b.ID,
	NumberOfTopics = COUNT(t.ID)
FROM
	Bookstore.Book b
	INNER JOIN Bookstore.BookTopic bt ON b.ID = bt.BookID
	INNER JOIN Bookstore.Topic t ON bt.TopicID = t.ID
GROUP BY
	b.ID