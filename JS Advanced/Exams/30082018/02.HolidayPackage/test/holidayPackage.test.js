const HolidayPackage = require('../holidayPackage');
const { assert } = require('chai');

describe('test HolidayPackage', () => {
    it('ctor iniatlizes correct values', () => {
        let destination = 'Gabrovo';
        let season = 'summer';
        
        let package = new HolidayPackage(destination, season);

        assert.equal(package.destination, destination);
        assert.equal(package.season, season);
        assert.isFalse(package.insuranceIncluded);
        assert.deepEqual(package.vacationers, []);
    });
    it('should throw when adding non string vacationer value', () => {
        let destination = 'Gabrovo';
        let season = 'summer';
        
        let package = new HolidayPackage(destination, season);

        assert.throw(() => package.addVacationer(100));
        assert.throw(() => package.addVacationer(undefined));
        assert.throw(() => package.addVacationer([]));
    });
    it('should throw when adding empty string vacationer value', () => {
        let destination = 'Gabrovo';
        let season = 'summer';
        
        let package = new HolidayPackage(destination, season);

        assert.throw(() => package.addVacationer(' '));
    });
    it('should throw when adding incorrect value for vacationer', () => {
        let destination = 'Gabrovo';
        let season = 'summer';
        
        let package = new HolidayPackage(destination, season);

        assert.throw(() => package.addVacationer('Bobby Andre Silva'));
    });
    it('should add vacationer when values are correct', () => {
        let destination = 'Gabrovo';
        let season = 'summer';
        
        let package = new HolidayPackage(destination, season);
        package.addVacationer('Andre Silva');
        
        assert.isTrue(package.vacationers.includes('Andre Silva'));
    });
    it('showVacationers should show correct result when there are vacationers', () => {
        let destination = 'Gabrovo';
        let season = 'summer';
        let first = 'Ivan Goshev';
        let second = 'Vacho Vachev';
        
        let package = new HolidayPackage(destination, season);
        package.addVacationer(first);
        package.addVacationer(second);

        let expected = 'Vacationers:\n' + first + '\n' + second;

        assert.equal(package.showVacationers(), expected);
    });
    it('showVacationers should show correct result when there are no vacationers', () => {
        let destination = 'Gabrovo';
        let season = 'summer';
        
        let package = new HolidayPackage(destination, season);

        assert.equal(package.showVacationers(), 'No vacationers are added yet');
    });
    it('setting non boolean to insuranceIncluded should throw', () => {
        let destination = 'Gabrovo';
        let season = 'summer';
        
        let package = new HolidayPackage(destination, season);

        assert.throw(() => package.insuranceIncluded('da'));
        assert.throw(() => package.insuranceIncluded(undefined));
        assert.throw(() => package.insuranceIncluded(100));
    });
    it('setting boolean to insuranceIncluded should work', () => {
        let destination = 'Gabrovo';
        let season = 'summer';
        
        let package = new HolidayPackage(destination, season);
        package.insuranceIncluded = true;

        assert.isTrue(package.insuranceIncluded);
    });
    it('generateHolidayPackage throws when there are no vacationers', () => {
        let destination = 'Gabrovo';
        let season = 'summer';
        
        let package = new HolidayPackage(destination, season);

        assert.throw(() => package.generateHolidayPackage());
    });
    it('generateHolidayPackage returns correct result when season is weak and there is no insurance', () => {
        let destination = 'Gabrovo';
        let season = 'Spring';        
        let first = 'Ivan Goshev';
        let second = 'Vacho Vachev';
        
        let package = new HolidayPackage(destination, season);
        package.addVacationer(first);
        package.addVacationer(second);
        
        let expected = "Holiday Package Generated\n" +
        "Destination: " + 'Gabrovo' + "\n" +
        package.showVacationers() + "\n" +
        "Price: " + 800;

        assert.equal(package.generateHolidayPackage(), expected);
    });
    it('generateHolidayPackage returns correct result when season is not weak and there is an insurance', () => {
        let destination = 'Gabrovo';
        let season = 'Summer';        
        let first = 'Ivan Goshev';
        let second = 'Vacho Vachev';
        
        let package = new HolidayPackage(destination, season);
        package.addVacationer(first);
        package.addVacationer(second);
        package.insuranceIncluded = true;
        
        let expected = "Holiday Package Generated\n" +
        "Destination: " + 'Gabrovo' + "\n" +
        package.showVacationers() + "\n" +
        "Price: " + 1100;

        assert.equal(package.generateHolidayPackage(), expected);
    });
    it('generateHolidayPackage returns correct result when season is not weak and there is no insurance', () => {
        let destination = 'Gabrovo';
        let season = 'Summer';        
        let first = 'Ivan Goshev';
        let second = 'Vacho Vachev';
        
        let package = new HolidayPackage(destination, season);
        package.addVacationer(first);
        package.addVacationer(second);
        
        let expected = "Holiday Package Generated\n" +
        "Destination: " + 'Gabrovo' + "\n" +
        package.showVacationers() + "\n" +
        "Price: " + 1000;

        assert.equal(package.generateHolidayPackage(), expected);
    });
    it('generateHolidayPackage returns correct result when season is weak and there is an insurance', () => {
        let destination = 'Gabrovo';
        let season = 'Spring';        
        let first = 'Ivan Goshev';
        let second = 'Vacho Vachev';
        
        let package = new HolidayPackage(destination, season);
        package.addVacationer(first);
        package.addVacationer(second);
        package.insuranceIncluded = true;
        
        let expected = "Holiday Package Generated\n" +
        "Destination: " + 'Gabrovo' + "\n" +
        package.showVacationers() + "\n" +
        "Price: " + 900;

        assert.equal(package.generateHolidayPackage(), expected);
    });
});