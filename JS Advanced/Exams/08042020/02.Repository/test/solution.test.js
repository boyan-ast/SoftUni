let { Repository } = require("../solution.js");
let { assert } = require('chai');

describe("test Repository class", function () {
    describe("test constructior", function () {
        it("should initialize new repo with correct properties", function () {
            let properties = {
                name: "string",
                age: "number",
                birthday: "object"
            };

            let testRepo = new Repository(properties);

            assert.deepEqual(testRepo.props, properties);
            assert.deepEqual(testRepo.data, new Map());
            assert.equal(testRepo.nextId(), 0);
            assert.equal(testRepo.count, 0);
        });
    });
    describe('test add method', () => {
        it('should return correct count with empty data', () => {
            let properties = {
                name: "string",
                age: "number",
                birthday: "object"
            };

            let testRepo = new Repository(properties);

            assert.equal(testRepo.count, 0);
        });
        it('should return correct count with non empty data', () => {
            let properties = {
                name: "string",
                age: "number",
                birthday: "object"
            };

            let entity = {
                name: "Pesho",
                age: 22,
                birthday: new Date(1998, 0, 7)
            };

            let testRepo = new Repository(properties);
            testRepo.add(entity);
            testRepo.add(entity);

            assert.equal(testRepo.count, 2);
        });
        it('add should throw exception when new entity doesn\'t have property', () => {
            let properties = {
                name: "string",
                age: "number",
                birthday: "object"
            };

            let entity = {
                name: "Pesho",
                birthday: {}
            };

            let testRepo = new Repository(properties);

            assert.throw(() => testRepo.add(entity), 'Property age is missing from the entity!');
        });
        it('add should throw exception when new entity have property with different type', () => {
            let properties = {
                name: "string",
                age: "number",
                birthday: "object"
            };

            let entity = {
                name: 1,
                age: 'sto',
                birthday: {}
            };

            let testRepo = new Repository(properties);

            assert.throw(() => testRepo.add(entity), TypeError);
        });
        it('add should throw exception when new entity have more properties', () => {
            let properties = {
                name: "string",
                age: "number",
                birthday: "object"
            };

            let entity = {
                name: "Pesho",
                age: 'sto',
                birthday: new Date(1998, 0, 7),
                gender: 'male'
            };

            let testRepo = new Repository(properties);

            assert.throws(() => testRepo.add(entity), TypeError);
        });
        it('add should add correctly new entities', () => {
            let properties = {
                name: "string",
                age: "number",
                birthday: "object"
            };

            let entity = {
                name: "Pesho",
                age: 22,
                birthday: {}
            }


            let entity2 = {
                name: "Gogi",
                age: 22,
                birthday: {}
            }

            let expectedData = new Map();
            expectedData.set(0, entity);
            expectedData.set(1, entity2);

            let testRepo = new Repository(properties);
            testRepo.add(entity);
            testRepo.add(entity2);

            assert.deepEqual(testRepo.data, expectedData);
            assert.isTrue(testRepo.data.has(1));
            assert.equal(testRepo.add(entity), 2);
            assert.equal(testRepo.nextId(), 3);
        });
        it('should return the new object id', () => {
            let properties = {
                name: "string",
                age: "number",
                birthday: "object"
            };

            let entity = {
                name: "Pesho",
                age: 22,
                birthday: {}
            };

            let testRepo = new Repository(properties);

            assert.equal(testRepo.add(entity), 0);
        });
    });
    describe('test getId method', () => {
        it('should throw exception when the id is not existing', () => {
            let properties = {
                name: "string",
                age: "number",
                birthday: "object"
            };

            let entity = {
                name: "Pesho",
                age: 22,
                birthday: {}
            };

            let testRepo = new Repository(properties);
            testRepo.add(entity);
            testRepo.add(entity);

            assert.throw(() => testRepo.getId(3), 'Entity with id: 3 does not exist!');
            assert.throw(() => testRepo.getId(2), 'Entity with id: 2 does not exist!');
        });
        it('should throw exception when the collection is empty', () => {
            let properties = {
                name: "string",
                age: "number",
                birthday: "object"
            };

            let testRepo = new Repository(properties);

            assert.throw(() => testRepo.getId(2), 'Entity with id: 2 does not exist!');
        });
        it('should return correct result when id exists', () => {
            let properties = {
                name: "string",
                age: "number",
                birthday: "object"
            };

            let entity = {
                name: "Pesho",
                age: 22,
                birthday: {}
            };
            let entity2 = {
                name: "Gogo",
                age: 42,
                birthday: {}
            };

            let testRepo = new Repository(properties);
            testRepo.add(entity);
            testRepo.add(entity2);

            assert.deepEqual(testRepo.data.get(1), entity2);
        });
    });

    describe('test update method', () => {
        it('should throw exception when the id doesnt exist', () => {
            let properties = {
                name: "string",
                age: "number",
                birthday: "object"
            };

            let entity = {
                name: "Pesho",
                age: 22,
                birthday: {}
            };

            let testRepo = new Repository(properties);
            testRepo.add(entity);

            assert.throw(() => testRepo.update(2, entity), 'Entity with id: 2 does not exist!');
            assert.throw(() => testRepo.update(1, entity), 'Entity with id: 1 does not exist!');
        });
        it('should throw exception when new entity doesn\'t have a property', () => {
            let properties = {
                name: "string",
                age: "number",
                birthday: "object"
            };

            let entity = {
                name: "Pesho",
                age: 22,
                birthday: {}
            };

            let entity2 = {
                name: "Pesho",
                birthday: {}
            };

            let testRepo = new Repository(properties);
            testRepo.add(entity);

            assert.throw(() => testRepo.update(0, entity2), 'Property age is missing from the entity!');
        });

        it('should throw exception when the the new entity have a differet type of property', () => {
            let properties = {
                name: "string",
                age: "number",
                birthday: "object"
            };

            let entity = {
                name: "Pesho",
                age: 22,
                birthday: {}
            };

            let entity2 = {
                name: 1,
                age: 22,
                birthday: {}
            };

            let testRepo = new Repository(properties);
            testRepo.add(entity);

            assert.throw(() => testRepo.update(0, entity2), TypeError);
        });
        it('should update existing entity correcty', () => {
            let properties = {
                name: "string",
                age: "number",
                birthday: "object"
            };

            let entity = {
                name: "Pesho",
                age: 22,
                birthday: {}
            };

            let entity2 = {
                name: "Gergi",
                age: 62,
                birthday: {}
            };

            let testRepo = new Repository(properties);
            testRepo.add(entity);
            testRepo.update(0, entity2);

            assert.deepEqual(testRepo.getId(0), entity2);
            assert.notDeepEqual(testRepo.getId(0), entity);
            assert.equal(testRepo.count, 1);
        });
    });
    describe('test del method', () => {
        it('should throw exception when the id doesn\'t exist', () => {
            let properties = {
                name: "string",
                age: "number",
                birthday: "object"
            };

            let entity = {
                name: "Pesho",
                age: 22,
                birthday: {}
            };

            let testRepo = new Repository(properties);
            testRepo.add(entity);
            testRepo.add(entity);

            assert.throw(() => testRepo.del(2), 'Entity with id: 2 does not exist!');
            assert.throw(() => testRepo.del(100), 'Entity with id: 100 does not exist!');
        });
        it('should decrease the count when entity deleted', () => {
            let properties = {
                name: "string",
                age: "number",
                birthday: "object"
            };

            let entity = {
                name: "Pesho",
                age: 22,
                birthday: {}
            };

            let testRepo = new Repository(properties);
            testRepo.add(entity);
            testRepo.add(entity);

            testRepo.del(0);
            assert.equal(testRepo.count, 1);
        });
        it('should remove entity correctly', () => {
            let properties = {
                name: "string",
                age: "number",
                birthday: "object"
            };

            let entity = {
                name: "Pesho",
                age: 22,
                birthday: {}
            };

            let entity2 = {
                name: "Kombi",
                age: 72,
                birthday: {}
            };

            let testRepo = new Repository(properties);
            testRepo.add(entity);
            testRepo.add(entity2);
            testRepo.del(1);

            assert.isFalse(testRepo.data.has(1));
        });
    });
});

