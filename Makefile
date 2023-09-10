build:
	docker build -t simplecrudapi:dev .

run:
	docker run -it --rm -p 5000:5000 -v $(PWD)/SimpleCRUDAPI:/app simplecrudapi:dev

